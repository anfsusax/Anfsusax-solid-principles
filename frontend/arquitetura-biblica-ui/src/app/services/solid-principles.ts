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
  private apiUrl = 'http://localhost:5278/api/solid';

  constructor(private http: HttpClient) {}

  getPrincipios(): Observable<PrincipioSolid[]> {
    return this.http.get<PrincipioSolid[]>(this.apiUrl);
  }

  getPrincipioPorId(id: number): Observable<PrincipioSolid> {
    return this.http.get<PrincipioSolid>(`${this.apiUrl}/${id}`);
  }

  getPrincipioPorSigla(sigla: string): Observable<PrincipioSolid> {
    return this.http.get<PrincipioSolid>(`${this.apiUrl}/${sigla}`);
  }
}
