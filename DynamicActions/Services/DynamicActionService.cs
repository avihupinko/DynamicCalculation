using DynamicActions.Extensions;
using DynamicActions.Interfaces;
using DynamicActions.Models;
using DynamicActions.ViewModels;
using DynamicExpresso;
using Microsoft.EntityFrameworkCore;
using NCalc;

namespace DynamicActions.Services
{
    public class DynamicActionService : IDynamicActionService
    {
        private readonly DynamicActionsContext _context;

        public DynamicActionService(DynamicActionsContext context)
        {
            _context = context;
        }

        public async Task<DynamicActionLogicModel> Add(DynamicActionCreateLogicModel model)
        {
            if (string.IsNullOrEmpty(model.DynamicActionType))
                throw new ValidationException("Missing Dynamic Action Type");

            if (!Enum.TryParse(model.DynamicActionType, out DynamicActionType type))
                throw new ValidationException("Invalid Dynamic Action Type");

            if (string.IsNullOrEmpty(model.Expression))
                throw new ValidationException("Missing Expression");

            if (string.IsNullOrEmpty(model.Name))
                throw new ValidationException("Missing Name");

            if (await this._context.DynamicActions.AnyAsync(x => x.Name.ToLower() == model.Name.ToLower()))
                throw new ValidationException("Dynamic Action with specified name already exists");

            var result = GetResult(type, model.Expression, "1", "1");
            if (string.IsNullOrEmpty(result))
                throw new ValidationException("Invalid Expression provided");

            DynamicAction action = new DynamicAction
            {
                Expression = model.Expression,
                Created = DateTime.UtcNow,
                DynamicActionType = type,
                Name = model.Name
            };
            this._context.DynamicActions.Add(action);
            await this._context.SaveChangesAsync();
            return new DynamicActionLogicModel
            {
                Name = action.Name,
                DynamicActionType = action.DynamicActionType.ToString(),
                Created = action.Created,
                Id = action.Id,
                Expression = action.Expression,
            };
        }

        public async Task<List<DynamicActionLogicModel>> GetAvailableActions()
        {
            return await this._context.DynamicActions.Select(x =>
            new DynamicActionLogicModel
            {
                Name = x.Name,
                Created = x.Created,
                Id = x.Id,
                DynamicActionType = x.DynamicActionType.ToString(),
                Expression = x.Expression
            }).ToListAsync();
        }

        public async Task<DynamicActionCalculateResultLogicModel> Calculate(DynamicActionCalculateLogicModel model)
        {
            var action = await this._context.DynamicActions.FirstOrDefaultAsync(x => x.Id == model.DynamicActionId);
            if (action == null)
                throw new ValidationException($"Provided Dynamic Action Id ('{model.DynamicActionId}') not found");

            var result = GetResult(action.DynamicActionType, action.Expression, model.X, model.Y);
            if (string.IsNullOrEmpty(result))
                throw new ValidationException("Action couldn't be applied on supplied inputs");

            DynamicActionHistory history = new DynamicActionHistory
            {
                Created = DateTime.UtcNow,
                DynamicActionId = model.DynamicActionId,
                Result = result,
                X = model.X,
                Y = model.Y
            };
            this._context.DynamicActionHistorys.Add(history);
            await this._context.SaveChangesAsync();

            var res = new DynamicActionCalculateResultLogicModel
            {
                Result = result,
            };
            IQueryable<DynamicActionHistory> query = this._context.DynamicActionHistorys.Where(x => x.DynamicActionId == action.Id);

            if (action.DynamicActionType == DynamicActionType.Numeric)
            {
                res.Avg = await query.AverageAsync(x => Convert.ToDecimal(x.Result));
                res.Max = await query.MaxAsync(x => Convert.ToDecimal(x.Result));
                res.Min = await query.MinAsync(x => Convert.ToDecimal(x.Result));
            }
            res.LastMonth = await query.Where(x => x.Created >= DateTime.Today.AddMonths(-1)).CountAsync();
            return res;
        }

        public string GetResult(DynamicActionType type, string expression, string x, string y)
        {
            try
            {
                switch (type)
                {
                    case DynamicActionType.Numeric:
                        Expression e = new(expression);
                        if (!decimal.TryParse(x, out decimal parameterX))
                        {
                            throw new ValidationException("Parameter X value must be decimal");
                        }

                        if (!decimal.TryParse(y, out decimal parameterY))
                        {
                            throw new ValidationException("Parameter Y value must be decimal");
                        }
                        e.Parameters["Y"] = parameterY;
                        e.Parameters["X"] = parameterX;

                        return e.Evaluate().ToString();
                    case DynamicActionType.Text:
                        var target = new Interpreter();
                        return target.Eval<string>(expression,
                            new Parameter("X", typeof(string), x),
                            new Parameter("Y", typeof(string), y));
                }
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ValidationException("Invalid Expression");
            }
            return null;
        }

        public async Task<List<DynamicActionHistoryLogicModel>> History(int dynamicActionId)
        {
            return await this._context.DynamicActionHistorys.Where(x => x.DynamicActionId == dynamicActionId)
                 .OrderByDescending(x => x.Created).Skip(1).Take(3)
                 .Select(x => new DynamicActionHistoryLogicModel
                 {
                     X = x.X,
                     Y = x.Y,
                     Created = x.Created,
                     Result = x.Result
                 }).ToListAsync();
        }
    }
}
