export const formattedDate = (date: Date | undefined) => {
    console.log('date formmated')
    if (date === undefined) {
        return new Date().toLocaleString('en-US', {
            month: '2-digit',
            day: '2-digit',
            year: 'numeric'
        })
    }
    return date.toLocaleString('en-US', {
        month: '2-digit',
        day: '2-digit',
        year: 'numeric'
    })
}

