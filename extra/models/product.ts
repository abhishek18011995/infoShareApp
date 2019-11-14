interface IProduct {
    id: string;
    name: string;
    price: IPrice;
    details: string;
    imgPath: string;
    type: string; 
    inStock: boolean;
    brandName: string;   
    gender: Gender;   
}

interface IProductList {
    products: IProduct[]    
}

interface IPrice {
    mrp: number;
    discountPrice: number;
}