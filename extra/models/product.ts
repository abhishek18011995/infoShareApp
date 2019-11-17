interface IProduct {
    id: string;
    name: string;
    price: IPrice;
    imgPath: string;
    type: string; 
    inStock: boolean;
    brandName: string; 
    productInfo: IProductInfo;  
}

// interface IProductList {
//     products: IProduct[]    
// }

interface IProductInfo {
    productDetails: string;
    gender: Gender;   
}

interface IPrice {
    mrp: number;
    discountPrice: number;
}