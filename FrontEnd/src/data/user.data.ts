import { Organization } from "./organization.data";

export class User {
    id: number;
    role: string;
    parentUser: string;
    email: string;
    firstname: string;
    lastname: string;
    phoneNumber: string;
    status: string;
    organization: Organization;
    password: string;
}