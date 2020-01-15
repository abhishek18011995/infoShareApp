export interface IContact {
    ownerName: string;
    address: IAddress;
}

export interface IAddress {
    buildingName: string;
    street: string;
    area: string;
    city: string;
    country: string;
    state: string;
    postalCode: number;
}

export interface IContactUs{
    name: string;
    email: string;
    subject: string;
    message: string;
}