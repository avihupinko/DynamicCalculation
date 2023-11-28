

export interface DynamicAction {
    id? : string; 
    expression : string; 
    name: string;
    created?: Date;
    dynamicActionType: string;
}

export interface DynamicActionCalculate{
    x: string;
    y: string;
    dynamicActionId: string;
}

export interface DynamicActionHistory {
    x: string;
    y: string;
    result: string;
    created: Date;
}

export interface DynamicActionCalculateResult{
    result: string;
    max: number;
    min: number;
    avg: number;
    lastMonth: number;
}


