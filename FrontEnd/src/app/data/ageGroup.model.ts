import { Category } from "./category.model";

export class AgeGroup {
    Id: number;
    Title: string;
    Gender: number;
    YearsFrom: number;
    YearsTo: number;
    EventID: number;
    Categories: Category[];    
}