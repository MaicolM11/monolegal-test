import { Component, OnInit } from '@angular/core';
import { Bill } from '../models/Bill';
import { ApiBillService } from '../services/api-bill.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public lst : Bill[];
  public headers = ["Client", "Location", "Nit", "Total", "Subtotal", "Iva",
        "Retention", "CreatedAt", "State", "IsPaid","PaymentDate","actions"];

  constructor(private apiBill: ApiBillService ) {
  }

  ngOnInit(): void {
    this.apiBill.getBills().subscribe(b => {
      this.lst = b;
    });

  }

  updateItem(id :string){
    this.apiBill.update(id).subscribe(response => {
      if(response){
        alert("cambio de estado satisfactorio ");
        this.ngOnInit();
      }else{

        alert("La factura esta en el ultimo estado");
      }
    });
  }

}
