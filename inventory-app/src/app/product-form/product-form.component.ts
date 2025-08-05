
import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ProductService } from '../services/product.service';
import { FormGroup } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-product-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './product-form.component.html'
})
export class ProductFormComponent {
  form!: FormGroup;

  constructor(private fb: FormBuilder, private productService: ProductService) {
    this.form = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(0)]],
      quantity: [0, [Validators.required, Validators.min(0)]],
    });
  }

  @Output() productCreated = new EventEmitter<void>();

  submit() {
    if (this.form.valid) {
      
      const product = this.form.value;
      this.productService.create(product).subscribe({
        next: () => {
          alert('Produto criado com sucesso!');
          this.productCreated.emit(); // notifica o pai para atualizar a lista
          this.form.reset();
        },
        error: (err) => {
          console.error('Erro ao criar produto', err);
          alert('Erro ao criar produto!');
        }
      });
    }
  }
}
