import { Organization } from "./organization.data";
import { UserRole } from "./user-role.data";
import { UserStatus } from "./userStatus.data";

export class User {
    id: number;
    userRoles: Array<UserRole>;
    parentUser: number;
    email: string;
    firstname: string;
    lastname: string;
    phoneNumber: string;
    statusId: number;
    status: UserStatus;
    organization: Organization;
    password: string;
}