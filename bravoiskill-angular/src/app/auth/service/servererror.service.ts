import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable()
export class ServerErrorService {
    constructor(private messageService: MessageService) { }

    showError(err) {
        this.messageService.add({
            severity: 'error',
            summary: 'Error Message',
            detail: '(' + err.error.id + ') : ' + err.error.message
        });
    }

    onConfirm() {
        this.messageService.clear('c');
    }

    onReject() {
        this.messageService.clear('c');
    }
}
