import { Gender } from "../enums/gender.enum";
import { DanKyu } from "./danKyu.data";
import { User } from "./user.data";
import { WeightCategory } from "./weight-category.data";

export class Judoka {
    id: number;
    firstname: string;
    lastname: string;
    gender: Gender;
    birthYears: number;
    danKyu: DanKyu;
    user: User;
    points: number;
    weightCategories: Array<WeightCategory>;
}
