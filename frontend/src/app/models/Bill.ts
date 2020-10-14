export interface Bill {
  id : string;
  location : string;
  total : number;
  subtotal : number;
  iva : number;
  retention: number;
  createAt : any;
  state : string;
  isPaid: boolean;
  paymentDate: any;
  nameClient: string;
  nit: string;
}
