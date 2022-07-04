import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { PoNotificationService, PoSelectOption } from '@po-ui/ng-components';
import { cadastrarService } from 'src/app/services/cadastrar/cadastrar.service';
import { GeralService } from 'src/app/services/geral/geral.service';
import { LocalStorageService } from 'src/app/services/local-storage/local-storage.service';
import { CadastroDto } from 'src/app/utility/cadastrarDTO';

@Component({
  selector: 'app-cadastrar-page',
  templateUrl: './cadastrar-page.component.html',
  styleUrls: ['./cadastrar-page.component.css'],

})
export class CadastrarPageComponent implements OnInit {
  
    formulario: FormGroup;
    setores: Array<PoSelectOption>;
    dto: CadastroDto = {Nome: '' , DtaNascimento: null, Telefone: '', Email: '', Cpf: '', Setor: '', Endereco: ''};
    constructor(private router: Router, 
    private formBuilder: FormBuilder,
    private poNotification: PoNotificationService,
    private serviceCadastro: cadastrarService,
    private localStorage: LocalStorageService,
    private serviceGeral: GeralService) { }

  ngOnInit(): void {
    this.setores = [
      {label: 'TI', value: 1},
      {label: 'Financeiro', value: 2},
      {label: 'RH', value: 3},
      {label: 'Outros', value: 4},
    ]
    this.formulario = this.formBuilder.group({

      nome: '',
      data: '',
      endereco: '',
      telefone: '',
      email: '',
      cpf: '',
      setor: ''
    })
    }

    voltar(){
      this.router.navigate(['']);
    }
    finalizarCadastro(){
    if(this.formulario.controls['nome'].value == '' || this.formulario.controls['cpf'].value == '' || this.formulario.controls['endereco'].value == '' || this.formulario.controls['setor'].value == '' || this.formulario.controls['data'].value == ''|| this.formulario.controls['telefone'].value == ''|| this.formulario.controls['email'].value == ''){
      this.poNotification.warning('Preencha os campos para continuar');
    }else{
      this.dto.Nome = this.formulario.controls['nome'].value;
      this.dto.Cpf = this.formulario.controls['cpf'].value;
      this.dto.Endereco = this.formulario.controls['endereco'].value;
      this.dto.Setor = this.formulario.controls['setor'].value;
      this.dto.DtaNascimento = this.formulario.controls['data'].value;
      this.dto.Telefone = this.formulario.controls['telefone'].value;
      this.dto.Email = this.formulario.controls['email'].value;
      this.serviceCadastro.postFuncionario(this.dto).subscribe();
    }
  }
}
