import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { PoNotificationService, PoSelectOption, PoTableColumn } from '@po-ui/ng-components';
import { GeralService } from 'src/app/services/geral/geral.service';
import { IndexService } from 'src/app/services/index/index.service';
import { LocalStorageService } from 'src/app/services/local-storage/local-storage.service';

import { ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

import { PoModalAction, PoModalComponent } from '@po-ui/ng-components';
import { CadastroDto } from 'src/app/app.component';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css'],
  providers: [GeralService],
  
})
export class IndexComponent implements OnInit {
  hiringProcessesColumns: Array<PoTableColumn>;
  hiringProcessesFiltered: Array<object>;
  formulario: FormGroup;
  @ViewChild('reactiveFormData', { static: true }) reactiveFormModal: PoModalComponent;


  reactiveForm: FormGroup;

  constructor(private router: Router,
    private poNotification: PoNotificationService,
    private datePipe: DatePipe,
    private serviceGeral: GeralService,
    private indexService: IndexService,
    private fb: FormBuilder,
    private localStorage: LocalStorageService,
    ) { this.createReactiveForm();}
    
    
    public readonly modalPrimaryAction: PoModalAction = {
      action: () => this.reactiveFormModal.close(),
      label: 'Close'
    };
    
    
    createReactiveForm() {
      this.reactiveForm = this.fb.group({
        name: ['', Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(30)])],
        address: ['', Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
        email: ['', Validators.required],
      });
    }
    saveForm() {
      this.reactiveFormModal.open();
    }


    ngOnInit(): void {
      this.getFunionario();


     //this.getDadosFuncionario();
     //this.buscarPorNome(this.localStorage.get('seqFuncionario'));
   
      this.hiringProcessesColumns = [
        { property: 'id', label: 'ID', visible: false},
        { property: 'nome', label: 'Nome', width: '20%', },
        { property: 'email', label: 'E-mail', width: '15%' },
        { property: 'telefone', label: 'Telefone', width: '15%' },
        { property: 'cpf', label: 'CPF', width: '15%' },
        { property: 'dtanasc', label: 'Data de Nascimento', width: '15%' },
        { property: 'setor', label: 'Setor de Atuação', width: '15%' },
      ]
  
      this.hiringProcessesFiltered = [
      ]
    }
    
  
    excluirFuncionario(value, row){
      console.log(value.id);
    }
  
    exibeInfo(value, row){
  }


  irCadastro(){
    this.router.navigate(['/irCadastro']);
  }

  getFunionario(){
    this.serviceGeral.getFuncionarioTodos().subscribe((dados: {items: Array<any>}) =>{
          dados.items.forEach(element => {
            var dtanasce = this.datePipe.transform(element.dtaNascimento, 'dd/MM/yyyy');
            var setorAux = '';

            if(element.setor == '1'){
              setorAux = 'TI';
            }else if (element.setor == '2'){
              setorAux = 'Financeiro';
    
            }else if(element.setor == '3'){
              setorAux = 'RH';
            }else{
              setorAux = 'Outros';
            }
            this.hiringProcessesFiltered.push({id: element.seqFuncionario, nome: element.nome, cpf: element.cpf, dtanasc: dtanasce, telefone: element.telefone, email: element.email, endereco: element.endereco, setor:setorAux});
          })

  })}

}