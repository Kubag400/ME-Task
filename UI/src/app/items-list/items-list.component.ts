import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Product } from '../Interfaces/Product';

@Component({
  selector: 'app-items-list',
  standalone: true,
  imports: [FormsModule], 
  templateUrl: './items-list.component.html',
  styleUrl: './items-list.component.css'
})
export class ItemsListComponent {
  @Input({required:true}) products!:Product[];
  @Output() refreshEvent = new EventEmitter<number>();
  
  defaultOption:boolean = true;
  descOption:boolean = false;
  ascOption:boolean = false;

  option:number = 0;
  
  onRefresh(){
    this.refreshEvent.emit(this.option)
  }
  onCheck(optionNumber:number){
    this.option = optionNumber;

    switch(optionNumber){
      case 0:
      {
        this.descOption = false;
        this.ascOption = false;
        this.defaultOption = true;
        break;
      }
  case 1:
    {
      this.ascOption = false;
      this.defaultOption = false;
      this.descOption= true;
      break;
    }
  case 2:
    {
      this.descOption = false;
      this.defaultOption = false;
      this.ascOption = true;
      break;
    }
  }
}
}

