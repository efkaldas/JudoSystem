import { Organization } from "./organization.data";
import { UserRole } from "./user-role.data";
import { DanKyu } from "./danKyu.data";
import { Judoka } from "./judoka.data";
import { Gender } from "../enums/gender.enum";
import { UserStatus } from "../enums/UserStatus.enum";

export class User {
    id: number;
    userRoles: Array<UserRole>;
    parentUser: number;
    email: string;
    firstname: string;
    lastname: string;
    phoneNumber: string;
    gender: Gender;
    birthDate: Date;
    danKyu: DanKyu;
    image: any;
    status: UserStatus;
    organization: Organization;
    judokas: Array<Judoka>;
    password: string;
}