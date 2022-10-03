import { User } from "./user.data";
import { AgeGroup } from "./age-group.data";

export class Competitions {
    id: number;
    title: string;
    description: string;
    place: string;
    competitionsDate: Date;
    entryFee: number;
    regulations: string;
    cardPayment: boolean;
    registrationStart: Date;
    registrationEnd: Date;
    judges: Array<User>;
    ageGroups: Array<AgeGroup>;
    dateCreated: Date;
}