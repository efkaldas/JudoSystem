import { OrganizationType } from "./organization-type.data";


export class Organization {
    id: number;
    exactName: string;
    shortName: string;
    country: string;
    city: string;
    address: string;
    image: string;
    organizationType: OrganizationType;
}