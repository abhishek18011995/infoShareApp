import { Gender } from './enums';

export interface IProduct {
    id: string;
    name: string;
    price: IPrice;
    imgPath: string;
    type: string;
    inStock: boolean;
    brandName: string;
    gender: Gender;
    productInfo: IProductInfo;
}

// interface IProductList {
//     products: IProduct[]    
// }

interface IProductInfo {
    productDetails: string;
}

interface IPrice {
    mrp: number;
    discountPrice: number;
}