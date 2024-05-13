import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/product.model';
import { CommonModule, NgFor } from '@angular/common';
import { Router } from '@angular/router';
import { AdminService } from '../../services/admin.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [NgFor, CommonModule],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.scss',
})
export class AdminComponent implements OnInit {
  products: Product[] = [];
  constructor(private adminService: AdminService, private router: Router) {}

  ngOnInit(): void {
    this.adminService.getAllProducts().subscribe({
      next: (products) => {
        this.products = products;
      },
      error: (response) => {
        console.log(response);
      },
    });
  }
}
