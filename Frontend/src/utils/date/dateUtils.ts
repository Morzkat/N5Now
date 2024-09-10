export const formattedDate = (strDate: string) => {

    return new Date(strDate).toLocaleString('en-US', {
        month: '2-digit',
        day: '2-digit',
        year: 'numeric'
    });
}

