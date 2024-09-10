import { Bounce, ToastOptions, toast } from "react-toastify";

const toastSettings: ToastOptions<unknown> = {
    position: 'top-right',
    // transition: Bounce
}

const success = (message: string) => {
    console.log('toast')
    toast.success(message
        
    //     , {
    //     position: 'top-right'
    // }

)
}

const error = (message: string) => {
    toast.error(message, toastSettings)
}

export { success, error }