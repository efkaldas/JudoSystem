import { Gender } from "./gender.data";
import { DanKyu } from "./DanKyu.data";
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
