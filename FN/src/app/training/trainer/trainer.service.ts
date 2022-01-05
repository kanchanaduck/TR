import { Injectable } from '@angular/core';

import { Trainer } from 'src/app/interfaces/trainer';

@Injectable({
  providedIn: 'root'
})
export class TrainerService {

  constructor() { }

  trainers: Trainer[] = [];

  addTrainer(trainer: Trainer) {
    this.trainers.push(trainer);
  }

  getTrainer() {
    return this.trainers;
  }

}
