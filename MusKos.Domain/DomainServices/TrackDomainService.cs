using System.Collections.Generic;
using MusKos.Domain.DomainServices.Interfaces;
using MusKos.Domain.Models;
using MusKos.Domain.Repositories;
using MusKos.Domain.UnitOfWork;

namespace MusKos.Domain.DomainServices
{
    public class TrackDomainService : ITrackDomainService
    {
        private readonly ITrackRepository trackRepository;
        private readonly IUnitOfWork unitOfWork;

        public TrackDomainService(ITrackRepository trackRepository, IUnitOfWork unitOfWork)
        {
            this.trackRepository = trackRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddTrack(Track track)
        {
            trackRepository.Add(track);
            unitOfWork.SaveChanges();
        }

        public void ChangeTrack()
        {
            unitOfWork.SaveChanges();
        }

        public void DeleteTrack(int id)
        {
            trackRepository.DeleteById(id);
            unitOfWork.SaveChanges();
        }

        public Track FindTrack(int id)
        {
           return trackRepository.FindTrack(id);
        }

        public List<Track> GetFiveTracks()
        {
            return trackRepository.GetFiveTracks();
        }

        public List<Track> GetTracks()
        {
            return trackRepository.GetAllWithAllAttachments();
        }
    }
}
