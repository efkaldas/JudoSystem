import { Organization } from "./organization.data";
import { UserRole } from "./user-role.data";

export class User {
    id: number;
    userRole: UserRole;
    parentUser: number;
    email: string;
    firstname: string;
    lastname: string;
    phoneNumber: string;
    status: string;
    organization: Organization;
    password: string;
}