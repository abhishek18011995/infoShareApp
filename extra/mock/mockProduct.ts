import { Gender } from "../models/enums";
import { IProduct } from "../models/product";

const products: IProduct[] = [{
    id: "11",
    name: "Chromozome Sando",
    description: "Chromozome Sando",
    imgPath: "string",
    type: "innerwear",
    inStock: true,
    price: {
        mrp: 300,
        discountPrice: 250
    },
    brandName: "Chromozome",
    gender: Gender.MALE,
    color: "white"
},
{
    id: "12",
    name: "Killer jeans 12",
    description: "Killer jeans 12",
    imgPath: "string",
    type: "Jeans",
    price: {
        mrp: 2499,
        discountPrice: 1199
    },
    inStock: true,
    brandName: "Killer",
    gender: Gender.MALE,
    color: "black"
},
{
    id: "12",
    name: "jeans 12",
    description: "Levis jeans 12",
    imgPath: "string",
    type: "Jeans",
    price: {
        mrp: 2499,
        discountPrice: 1199
    },
    inStock: true,
    brandName: "Levis",
    gender: Gender.MALE,
    color: "black"
},
{
    id: "113",
    name: "blue Jacket",
    description: "Celio Blue Jacket",
    price: {
        mrp: 2499,
        discountPrice: 1199
    },
    imgPath: "string",
    type: "Jacket",
    inStock: true,
    brandName: "Celio",
    gender: Gender.FEMALE,
    color: "blue"
}]