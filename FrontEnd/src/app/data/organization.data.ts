import { OrganizationType } from "../enums/organizationType";


export class Organization {
    id: number;
    exactName: string;
    shortName: string;
    country: string;
    city: string;
    address: string;
    image: string;
    type: OrganizationType;
}