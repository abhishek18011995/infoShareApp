interface IProduct {
    id: string;
    name: string;
    productInfo: IProductInfo;
    imgPath: string;
    type: string;
    inStock: boolean;
    brandName: string;
}

// interface IProductList {
//     products: IProduct[]    
// }

interface IProductInfo {
    productDetails: string;
    price: IPrice;
    gender: Gender;
}

interface IPrice {
    mrp: number;
    discountPrice: number;
}