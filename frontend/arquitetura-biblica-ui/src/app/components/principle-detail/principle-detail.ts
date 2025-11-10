import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { Subscription } from 'rxjs';
import { SolidPrinciplesService, PrincipioSolid, BlocoCodigoResponsabilidade } from '../../services/solid-principles';
import { ideiasPraticas, passosGuiados, resumoPorSigla } from '../../shared/principle-guides';

@Component({
  selector: 'app-principle-detail',
  standalone: true,
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule
  ],
  templateUrl: './principle-detail.html',
  styleUrls: ['./principle-detail.scss']
})
export class PrincipleDetailComponent implements OnInit, OnDestroy {
  principio: PrincipioSolid | null = null;
  isLoading = true;
  error: string | null = null;

  private subscription = new Subscription();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private solidService: SolidPrinciplesService
  ) {}

  ngOnInit(): void {
    this.subscription.add(
      this.route.paramMap.subscribe(params => {
        const sigla = params.get('sigla');
        if (!sigla) {
          this.error = 'Princípio não informado.';
          this.isLoading = false;
          return;
        }
        this.carregarPrincipio(sigla);
      })
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  private carregarPrincipio(sigla: string): void {
    this.isLoading = true;
    this.error = null;
    this.principio = null;

    this.subscription.add(
      this.solidService.getPrincipioPorSigla(sigla).subscribe({
        next: principio => {
          this.principio = {
            ...principio,
            blocosCodigo: principio.blocosCodigo ?? []
          };
          this.isLoading = false;
        },
        error: err => {
          console.error('Erro ao carregar princípio:', err);
          this.error = 'Não encontramos esse princípio. Verifique a sigla e tente novamente.';
          this.isLoading = false;
        }
      })
    );
  }

  obterResumo(sigla: string | undefined): string[] {
    if (!sigla) return [];
    return resumoPorSigla[sigla.toUpperCase()] ?? [];
  }

  obterPassos(sigla: string | undefined) {
    if (!sigla) return [];
    return passosGuiados[sigla.toUpperCase()] ?? [];
  }

  obterIdeias(sigla: string | undefined): string[] {
    if (!sigla) return [];
    return ideiasPraticas[sigla.toUpperCase()] ?? [];
  }

  voltar(): void {
    this.router.navigate(['/']);
  }

  classeResponsabilidade(bloco: BlocoCodigoResponsabilidade): string {
    const mapa: Record<string, string> = {
      model: 'modelo',
      contract: 'contrato',
      validator: 'validador',
      repository: 'repositorio',
      infrastructure: 'infraestrutura',
      service: 'servico',
      extension: 'extensao',
      implementation: 'implementacao',
      bootstrap: 'entrada'
    };

    return `responsabilidade-${mapa[bloco.papel?.toLowerCase()] ?? 'generico'}`;
  }

  nomeResponsabilidade(bloco: BlocoCodigoResponsabilidade): string {
    const mapa: Record<string, string> = {
      model: 'Modelo de dados',
      contract: 'Contrato/Interface',
      validator: 'Validação',
      repository: 'Repositório',
      infrastructure: 'Infraestrutura',
      service: 'Regra de negócio',
      extension: 'Extensão',
      implementation: 'Implementação',
      bootstrap: 'Ponto de entrada'
    };

    return mapa[bloco.papel?.toLowerCase()] ?? 'Responsabilidade';
  }
}
