import { Gender } from "../models/enums";
import { IProduct } from "../models/product";

const products: IProduct[] = [{
    id: '11',
    name: 'Chromozome Sando',
    productInfo: {
        productDetails: 'Chromozome Sando'
    },
    imgPath: 'string',
    type: 'innerwear',
    inStock: true,
    price: {
        mrp: 300,
        discountPrice: 250
    },
    brandName: 'Chromozome',
    gender: Gender.MALE
},
{
    id: '12',
    name: 'Killer jeans 12',
    productInfo: {
        productDetails: 'Killer jeans 12'
    },
    imgPath: 'string',
    type: 'Jeans',
    price: {
        mrp: 2499,
        discountPrice: 1199
    },
    inStock: true,
    brandName: 'Chromozome',
    gender: Gender.MALE
},
{
    id: '113',
    name: 'Celio Jacket',
    productInfo: {
        productDetails: 'Celio Blue Jacket'
    },
    price: {
        mrp: 2499,
        discountPrice: 1199
    },
    imgPath: 'string',
    type: 'Jacket',
    inStock: true,
    brandName: 'Celio',
    gender: Gender.FEMALE
}]