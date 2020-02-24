import { OrganizationType } from "./organization-type.data";


export class Organization {
    id: number;
    name: string;
    country: string;
    city: string;
    organizationType: OrganizationType;
}