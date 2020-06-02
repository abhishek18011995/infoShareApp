export interface IProduct {
    id: string;
    name: string;
    price: IPrice;
    imgPath: string;
    type: string;
    inStock: boolean;
    brandName: string;
    gender: Gender;
    description: string;
    color: string;
}

interface IPrice {
    mrp: number;
    discountPrice: number;
}

export enum Gender {
    MALE,
    FEMALE,
    UNISEX
}
