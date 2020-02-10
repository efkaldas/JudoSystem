import { Organization } from "./organization.data";

export class User {
    Id: number;
    Role: string;
    ParentUser: string;
    Email: string;
    Firstname: string;
    Lastname: string;
    PhoneNumber: string;
    Status: string;
    Organization: Organization;
    Password: string;
}