namespace SIS.HTTP.Sessions
{
    using System.Collections.Generic;

    public class HttpSession : IHttpSession
    {
        private Dictionary<string, object> parameters;
        
        public HttpSession(string id)
        {
            this.Id = id;
            this.parameters = new Dictionary<string, object>();
        }
        
        public string Id { get; }
        
        public object GetParameter(string name)
        {
            return this.parameters[name];
        }

        public bool ContainsParameter(string name)
        {
            return this.parameters.ContainsKey(name);
        }

        public void AddParameter(string name, object parameter)
        {
            this.parameters[name] = parameter;
        }

        public void RemoveParameter(string name)
        {
            this.parameters.Remove(name);
        }

        public void ClearParameters()
        {
            this.parameters.Clear();
        }
    }
}