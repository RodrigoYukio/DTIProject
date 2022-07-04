import { ModuleWithProviders } from "@angular/compiler/src/core";
import { RouterModule, Routes } from "@angular/router";
import { CadastrarPageComponent } from "./pages/agendar-page/cadastrar-page.component";
import { IndexComponent } from "./pages/index/index.component";

const APP_ROUTES: Routes = [
    { path: '', component: IndexComponent },
    { path: 'irCadastro', component: CadastrarPageComponent},
]

export const routing: ModuleWithProviders = RouterModule.forRoot(APP_ROUTES); 
