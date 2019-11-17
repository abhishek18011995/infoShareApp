interface IContact {
    ownerName: string;
    address: IAddress;
}

interface IAddress {
    buildingName: string;
    street: string;
    area: string;
    city: string;
    country: string;
    state: string;
    postalCode: number;
}

interface IContactUs{
    name: string;
    email: string;
    subject: string;
    message: string;
}