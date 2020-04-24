import { Organization } from "./organization.data";
import { UserRole } from "./user-role.data";
import { UserStatus } from "./userStatus.data";
import { Gender } from "./gender.data";
import { DanKyu } from "./DanKyu.data";
import { Judoka } from "./judoka.data";

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