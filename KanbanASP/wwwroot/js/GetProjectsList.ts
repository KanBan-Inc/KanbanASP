class ProjectList {

    static getProjectsList(): void {

        const headers: Headers = new Headers()
        headers.set('Content-Type', 'application/json')
        headers.set('Accept', 'application/json')

        const request: RequestInfo = new Request("", {
            method: 'GET',
            headers: headers
        })

    } 


}