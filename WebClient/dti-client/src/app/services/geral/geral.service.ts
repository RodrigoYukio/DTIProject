import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgModule} from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { PoNotificationService } from '@po-ui/ng-components';
import { UrlApiPadrao } from 'src/app/utility/urlApi';
import { CadastroDto } from 'src/app/app.component';
import { Observable } from 'rxjs';
import { IndexService } from '../index/index.service';

@Injectable({
  providedIn: 'root'
})
export class GeralService {


  constructor(private http: HttpClient, private poNotification: PoNotificationService) { }

  apiUrl = UrlApiPadrao.endereco;

  //getFuncionario(): Observable<IndexService[]>{
 //   return this.http.get<GeralService[]>(this.apiUrl);
//  }

  getFuncionario(idFuncionario: number){
    debugger;
    return this.http.get(`${this.apiUrl}CadastroFuncionario?SeqFuncionario=${idFuncionario}`);
  }

  getFuncionarioTodos(){
    return this.http.get(`${this.apiUrl}CadastroFuncionario`);
  }
  createFuncionario(model: CadastroDto){
    return this.http.post(`${this.apiUrl}Cadastro`, model);
 }
 EditFuncionario(idFuncionario: number){
  return this.http.put(`${this.apiUrl}Funcionario?SeqFuncionario=${idFuncionario}`, idFuncionario);
}


}
