import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { PoNotificationService } from '@po-ui/ng-components';
import { CadastroDto } from 'src/app/utility/cadastrarDTO';
import { UrlApiPadrao } from 'src/app/utility/urlApi';

@Injectable({
  providedIn: 'root'
})
export class cadastrarService {

  constructor(private router: Router, 
    private http: HttpClient,
    private poNotification: PoNotificationService,) { }

    apiUrl = UrlApiPadrao.endereco;


    postFuncionario(dto: CadastroDto){
      debugger;
      return this.http.post(`${this.apiUrl}CadastroFuncionario`, dto);
    }
}
