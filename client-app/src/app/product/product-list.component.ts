import { Component, OnInit } from '@angular/core';
import { ProductService } from './product.service';
import { IProduct } from './product';

@Component({
  selector: 'app-product',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
productList: IProduct[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getProductList();
  }

  getProductList() {
    this.productService.getProducts().subscribe(resp => {
      console.log(resp);
      this.productList = resp;
    });
  }

}
