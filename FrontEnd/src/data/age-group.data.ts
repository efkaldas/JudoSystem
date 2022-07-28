import { Gender } from "../enums/gender.enum";
import { Competitions } from "./competitions.data";
import { WeightCategory } from "./weight-category.data";

export class AgeGroup {
    id: number;
    title: string;
    competitions: Competitions;
    gender: Gender;
    yearsFrom: number;
    yearsTo: number;
    danKyuFrom: number;
    danKyuTo: number;
    competitionsDate: Date;
    weightInFrom: Date;
    weightInTo: Date;
    weightCategories: Array<WeightCategory>;
}
