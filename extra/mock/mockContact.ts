import { IContact } from "../models/contact";

const contact: IContact = {
    ownerName: 'Kumar Abhishek',
    address: {
        buildingName: '#15 Reeta Nest Thirumala PG',
        street: '3rd Cross Sandhyagappa Layout',
        area: 'Veeranapalya, Nagavara',
        city: 'Bangalore',
        country: 'India',
        state: 'Karnataka',
        postalCode: 560045
    }
};

const mockQuery = [{
    "name": "Abhi",
    "email": "abhishek18011995@gmail.com",
    "subject": "query",
    "messages": "want some more details"
},
{
    "name": "Abhi",
    "email": "abhishek18011995@gmail.com",
    "subject": "query",
    "messages": "want some more details"
}];

const mockWorkspace = [{
    workspace: "1111",
    reports: [{
        id: "1122",
        name: "WFM Outcomes Analytics1",
        category: "Color"
    }]
},
{
    workspace: "2222",
    reports: [{
        id: "2233",
        name: "WFM Outcomes Analytics2",
        category: "Sales"
    }]
}];
