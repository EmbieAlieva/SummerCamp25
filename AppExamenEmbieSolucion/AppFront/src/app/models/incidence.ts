export interface Incidence {
    id: number;
    nameClient: string;
    description: string;
    reportedAt: string;
    isUrgent: boolean;
    status: string; // 'Reported', 'InProgress', etc.
}
