
import { Component, signal } from '@angular/core';
import { ProductFormComponent } from './product-form/product-form.component';
import { ProductListComponent } from './product-list/product-list.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ProductFormComponent, ProductListComponent],
  templateUrl: './app.component.html'
})
export class AppComponent {
  refreshTrigger = signal(0);
  onProductCreated() {
    this.refreshTrigger.update(v => v + 1); // força o reload
  }
}
