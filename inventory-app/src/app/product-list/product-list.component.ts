
import { Component, effect, input } from '@angular/core';
import { ProductService } from '../services/product.service';
import { CommonModule } from '@angular/common';
import { Product } from '../services/product';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product-list.component.html'
})
export class ProductListComponent {
  products: Product[] = [];
  refreshTrigger = input.required<number>();

  constructor(private productService: ProductService) {
    effect(() => {
      // Este efeito será executado na inicialização e sempre que
      // o valor de refreshTrigger() for alterado.
      this.refreshTrigger();
      this.loadProducts();
    });
  }

  loadProducts() {
    this.productService.getAll().subscribe(data => this.products = data);
  }

  deleteProduct(id: number) {
    this.productService.delete(id).subscribe(() => this.loadProducts()); // Idealmente, isso emitiria um evento para o pai
  }
}
