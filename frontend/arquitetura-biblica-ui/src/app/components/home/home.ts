import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Router, RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { SolidPrinciplesService } from '../../services/solid-principles';

interface PrincipioSolid {
  id: number;
  nome: string;
  sigla: string;
  descricao: string;
  exemploCodigo: string;
  referenciaBiblica: string;
  versiculo: string;
  aplicacaoPratica: string;
}

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule
  ],
  templateUrl: './home.html',
  styleUrls: ['./home.scss']
})
export class Home implements OnInit {
  principios: PrincipioSolid[] = [];
  isLoading = true;
  error: string | null = null;

  constructor(
    private solidService: SolidPrinciplesService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.carregarPrincipios();
  }

  private carregarPrincipios(): void {
    this.isLoading = true;
    this.error = null;

    this.solidService.getPrincipios().subscribe({
      next: (data: PrincipioSolid[]) => {
        this.principios = data;
        this.isLoading = false;
      },
      error: (err: unknown) => {
        console.error('Erro ao carregar princípios:', err);
        this.error = 'Não foi possível carregar os princípios. Tente novamente mais tarde.';
        this.isLoading = false;
      }
    });
  }

  navegarParaDetalhes(principio: PrincipioSolid): void {
    this.router.navigate(['/principio', principio.sigla.toLowerCase()]);
  }
}
