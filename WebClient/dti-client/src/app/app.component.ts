import { Component } from '@angular/core';

import { PoMenuItem } from '@po-ui/ng-components';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  readonly menus: Array<PoMenuItem> = [
    { label: 'Home', action: this.onClick.bind(this) }
  ];

  private onClick() {
    alert('Clicked in menu item')
  }

}
export interface CadastroDto {
  seq_funcionario: number;
  nome: string;
  dtanasc: Date;
  endereco: string;
  telefone: string;
  email: string;
  cpf: string;
  setor: string;
}
