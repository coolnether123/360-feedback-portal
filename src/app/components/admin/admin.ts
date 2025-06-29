import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [MatCardModule],
  templateUrl: './admin.html',
  styleUrl: './admin.scss'
})
export class Admin {

}
