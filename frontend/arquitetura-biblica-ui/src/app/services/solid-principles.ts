import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface PrincipioSolid {
  id: number;
  nome: string;
  sigla: string;
  descricao: string;
  exemploCodigo: string;
  referenciaBiblica: string;
  versiculo: string;
  aplicacaoPratica: string;
  blocosCodigo?: BlocoCodigoResponsabilidade[];
}

export interface BlocoCodigoResponsabilidade {
  titulo: string;
  papel: string;
  codigo: string;
  explicacao?: string;
  corSugestao?: string;
}

@Injectable({
  providedIn: 'root',
})
export class SolidPrinciplesService {
  private readonly apiBaseUrl = this.resolveApiUrl();

  constructor(private http: HttpClient) {
    console.log('🔥 SolidPrinciplesService inicializado — API em', this.apiBaseUrl);
  }

  private resolveApiUrl(): string {
    const hostname = window.location.hostname;
    console.log('🔍 Host detectado:', hostname);

    if (hostname === 'localhost' || hostname === '127.0.0.1') {
      console.log('🏠 Ambiente local detectado — usando API em http://localhost:5278');
      return 'http://localhost:5278/api/solid';
    }

    console.log('🌐 Ambiente produção detectado — usando API Railway');
    return 'https://anfsusax-solid-principles-production.up.railway.app/api/solid';
  }

  getPrincipios(): Observable<PrincipioSolid[]> {
    return this.http.get<PrincipioSolid[]>(this.apiBaseUrl);
  }

  getPrincipioPorId(id: number): Observable<PrincipioSolid> {
    return this.http.get<PrincipioSolid>(`${this.apiBaseUrl}/${id}`);
  }

  getPrincipioPorSigla(sigla: string): Observable<PrincipioSolid> {
    return this.http.get<PrincipioSolid>(`${this.apiBaseUrl}/${sigla}`);
  }
}
