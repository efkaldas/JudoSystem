import { Organization } from "./organization.data";
import { UserRole } from "./user-role.data";
import { UserStatus } from "./userStatus.data";
import { DanKyu } from "./danKyu.data";
import { Judoka } from "./judoka.data";
import { Gender } from "../enums/gender.enum";

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
    image: string;
    statusId: number;
    status: UserStatus;
    organization: Organization;
    judokas: Array<Judoka>;
    password: string;
}