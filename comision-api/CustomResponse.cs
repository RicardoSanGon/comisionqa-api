namespace comision_api
{
    public class CustomResponse
    {
        private Object data;
        private string objectName;
        public CustomResponse(Object data)
        {
            this.data = data;
            this.objectName = data.GetType().Name;
        }

        public Object ok()
        {
            return new
            {
                status = 200,
                data = this.data
            };
        }

        public Object error()
        {
            return new
            {
                status = 500,
                data = this.data
            };
        }

        public Object notFound()
        {
            return new
            {
                status = 404,
                message = this.data
            };
        }

        public Object created()
        {
            return new
            {
                message = $"[{this.objectName}] created",
                status = 201,
                data = this.data
            };
        }

        public Object badRequest()
        {
            return new
            {
                status = 400,
                data = this.data
            };
        }

        public Object updated()
        {
            return new
            {
                message = $"[{this.objectName}] updated",
                status = 200,
                data = this.data
            };
        }

        public Object deleted()
        {
            return new
            {
                message = $"[{this.objectName}] deleted",
                status = 200,
                data = this.data
            };
        }

        internal object? unauthorized()
        {
            return new
            {
                status = 401,
                message = this.data
            };
        }
    }
}
